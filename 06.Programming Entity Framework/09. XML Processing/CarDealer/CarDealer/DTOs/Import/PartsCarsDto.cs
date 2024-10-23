﻿using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("Car")]
    public class PartsCarsDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("traveledDistance")]
        public long TraveledDistance { get; set; }

        [XmlArray("parts")]
        public PartDto[] Parts { get; set; }
    }

    [XmlType("partId")]
    public class PartDto
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }
    }
}