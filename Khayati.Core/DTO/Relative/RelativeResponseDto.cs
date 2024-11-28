﻿namespace Khayati.Core.DTO.Relative
{
    public class RelativeResponseDto
    {
        public int RelativeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? RelationshipType { get; set; } // e.g., Father, Baby, etc.
        public DateTime? DateOfBirth { get; set; }   // Optional, useful for babies
        public string? PhoneNumber { get; set; }     // Optional for relatives
        public string? EmailAddress { get; set; }    // Optional for relatives
        public string? Address { get; set; }         // Optional

        // Foreign key to link back to the customer
        public int CustomerId { get; set; }

        public string? FullName { get; set; }
        
    }
}