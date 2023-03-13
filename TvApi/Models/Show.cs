using Microsoft.Identity.Client.Extensions.Msal;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace TvApi.Models
{
    public class Show
    {
        
        [JsonProperty("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ShowId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        public ICollection<Cast> Casts { get; set; }
    }
}


