using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _4200Project.Models
{
    public class IndividualRecognition
    {
        [Key] // the data annotation is necessary because there is a field called, ID,
              // in the table and it is not the PK for the record
        public int RecognitionID { get; set; }
        //ID of person being recognized

        public Guid EID { get; set; }
        [ForeignKey(name: "EID")]

        public virtual Employee Employee { get; set; }

        [Display(Name = "Date of Recognition")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfRecognition { get; set; }
        //…
        [Required]
        [Display(Name = "Core Value")]
        public CoreValue award { get; set; }
        public enum CoreValue
        {
            Excellence = 1,
            Integrity = 2,
            Stewardship = 3,
            Culture = 4,
            Passion = 5,
            Innovation = 6,
            Balance = 7
        }

        public string Comments { get; set; }
    }



}