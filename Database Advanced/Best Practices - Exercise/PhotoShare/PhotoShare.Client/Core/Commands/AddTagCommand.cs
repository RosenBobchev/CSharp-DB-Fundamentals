namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Contracts;
    using Utilities;
    using Services;
    using Services.Contracts;

    public class AddTagCommand : ICommand
    {
        private readonly ITagService tagService;
        private readonly IUserSessionService userSessionService;

        public AddTagCommand(ITagService tagService, IUserSessionService userSessionService)
        {
            this.tagService = tagService;
            this.userSessionService = userSessionService;
        }

        public string Execute(string[] args)
        {
            string tagName = args[0];

            var tagExists = this.tagService.Exists(tagName);

            if (tagExists)
            {
                throw new ArgumentException($"Tag {tagName} exists!");
            }
            if (!userSessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            tagName = tagName.ValidateOrTransform();

            var tag = this.tagService.AddTag(tagName);

            return $"Tag {tagName} was added successfully!";
        }
    }
}
