using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using NGitLab.Impl.Json;

namespace NGitLab.Models
{
    public class ProjectIssueNoteCreate
    {
        [JsonIgnore]
        public int IssueId;

        [Required]
        [JsonPropertyName("body")]
        public string Body;

        [JsonPropertyName("confidential")]
        public bool Confidential;

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CreatedAt;

    }
}
