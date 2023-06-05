﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using NGitLab.Impl.Json;

namespace NGitLab.Models
{
    public class IssueCreate
    {
        [JsonIgnore]
        public int ProjectId { get => Id; set => Id = value; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [JsonIgnore]
        public int Id;

        [Required]
        [JsonPropertyName("title")]
        public string Title;

        [JsonPropertyName("description")]
        public string Description;

        [JsonPropertyName("assignee_id")]
        public int? AssigneeId;

        [JsonPropertyName("milestone_id")]
        public int? MileStoneId;

        [JsonPropertyName("labels")]
        public string Labels;

        [JsonPropertyName("confidential")]
        public bool Confidential;

        [JsonPropertyName("due_date")]
        [JsonConverter(typeof(DateOnlyConverter))]
        public DateTime? DueDate;

        [JsonPropertyName("epic_id")]
        public int? EpicId;

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CreatedAt;
    }
}
