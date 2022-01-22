﻿using Newtonsoft.Json;

namespace LibraryService.WebAPI.SeedData
{
    public class LibraryForm
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }
    }
}
