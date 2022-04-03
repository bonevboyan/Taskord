﻿namespace Taskord.Services.Chats.Models
{
    using Taskord.Data.Models.Enums;

    public class ChatServiceModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string LastReadMessageId { get; set; }

        public ChatType ChatType { get; set; }

        public bool IsAdmin { get; set; }

        public string TeamId { get; set; }

        public IEnumerable<ChatMemberServiceModel> Members { get; set; }

        public IEnumerable<ChatMessageServiceModel> Messages { get; set; }
    }
}
