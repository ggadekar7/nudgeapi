using System;
using System.Collections.Generic;
using System.Text;

namespace NudgeApi.DataContracts
{
    public class Configuration
    {
        public Ram Ram { get; set; }
        public Hdd Hdd { get; set; }
        public Color Color { get; set; }
    }

    public class Ram
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Price { get; set; }
    }
    public class Hdd
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Price { get; set; }
    }
    public class Color
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Price { get; set; }
    }

    public class ConfigurationResponse
    {
        public List<Ram> Rams { get; set; }
        public List<Hdd> Hdds { get; set; }
        public List<Color> Colors { get; set; }
    }

    public class DeleteConfigurationRequest
    {
        public string CType { get; set; }
        public int Id { get; set; }
    }
}
