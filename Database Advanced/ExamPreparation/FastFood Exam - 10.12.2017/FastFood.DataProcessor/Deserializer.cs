using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Import;
using FastFood.Models;
using FastFood.Models.Enums;
using Newtonsoft.Json;

namespace FastFood.DataProcessor
{
	public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportEmployees(FastFoodDbContext context, string jsonString)
		{
            var sb = new StringBuilder();
            var employees = new List<Employee>();

            var deserializedEmployees = JsonConvert.DeserializeObject<EmployeeDto[]>(jsonString);

            foreach (var employeeDto in deserializedEmployees)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Position position = GetPosition(context, employeeDto.Position);

                var employee = new Employee
                {
                    Name = employeeDto.Name,
                    Age = employeeDto.Age,
                    Position = position
                };

                employees.Add(employee);
                sb.AppendLine(string.Format(SuccessMessage, employeeDto.Name));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().Trim();
		}

        public static string ImportItems(FastFoodDbContext context, string jsonString)
		{
            var deserializedItems = JsonConvert.DeserializeObject<ItemDto[]>(jsonString);
            var sb = new StringBuilder();
            var items = new List<Item>();

            foreach (var itemDto in deserializedItems)
            {
                if (!IsValid(itemDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var item = context.Items.FirstOrDefault(x => x.Name == itemDto.Name);

                if (item != null || items.Any(x => x.Name == itemDto.Name))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Category category = GetCategory(context, itemDto.Category);

                item = new Item
                {
                    Name = itemDto.Name,
                    Price = itemDto.Price,
                    Category = category
                };

                items.Add(item);
                sb.AppendLine(string.Format(SuccessMessage, itemDto.Name));
            }

            context.Items.AddRange(items);
            context.SaveChanges();

            return sb.ToString().Trim();
		}

        public static string ImportOrders(FastFoodDbContext context, string xmlString)
		{
            var sb = new StringBuilder();
            var orderItems = new List<OrderItem>();
            var orders = new List<Order>();

            var serializer = new XmlSerializer(typeof(OrderDto[]), new XmlRootAttribute("Orders"));
            var deserializedOrders = (OrderDto[])serializer.Deserialize(new StringReader(xmlString));

            foreach (var orderDto in deserializedOrders)
            {
                bool isItemValid = true;

                if (!IsValid(orderDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                foreach (var itemDto in orderDto.OrderItems)
                {
                    if (!IsValid(itemDto))
                    {
                        sb.AppendLine(FailureMessage);
                        isItemValid = false;
                        break;
                    }
                }

                if (!isItemValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var employee = context.Employees.FirstOrDefault(x => x.Name == orderDto.Employee);

                if (employee == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var areItemsValid = AreItemsValid(context, orderDto.OrderItems);

                if (!areItemsValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var date = DateTime.ParseExact(orderDto.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                var orderType = Enum.Parse<OrderType>(orderDto.Type);

                var order = new Order
                {
                    Customer = orderDto.Customer,
                    Employee = employee,
                    DateTime = date,
                    Type = orderType
                };

                orders.Add(order);

                foreach (var itemDto in orderDto.OrderItems)
                {
                    var item = context.Items.FirstOrDefault(x => x.Name == itemDto.Name);

                    var orderItem = new OrderItem
                    {
                        Order = order,
                        Item = item,
                        Quantity = itemDto.Quantity
                    };

                    orderItems.Add(orderItem);
                }

                sb.AppendLine($"Order for {orderDto.Customer} on {date.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)} added");
            }

            context.OrderItems.AddRange(orderItems);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool AreItemsValid(FastFoodDbContext context, OrderItemDto[] orderItems)
        {
            foreach (var item in orderItems)
            {
                var itemExists = context.Items.Any(x => x.Name == item.Name);

                if (!itemExists)
                {
                    return false;
                }
            }

            return true;
        }

        private static Category GetCategory(FastFoodDbContext context, string itemCategory)
        {
            var category = context.Categories.FirstOrDefault(x => x.Name == itemCategory);

            if (category == null)
            {
                category = new Category
                {
                    Name = itemCategory
                };

                context.Categories.Add(category);
                context.SaveChanges();
            }

            return category;
        }

        private static Position GetPosition(FastFoodDbContext context, string employeePosition)
        {
            var position = context.Positions.FirstOrDefault(x => x.Name == employeePosition);

            if (position == null)
            {
                position = new Position
                {
                    Name = employeePosition
                };

                context.Positions.Add(position);
                context.SaveChanges();
            }

            return position;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            return System.ComponentModel.DataAnnotations.Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}