using System;

namespace  Isg_Mvc.Models{

    public class Blog{

        public int Id{get;set;}

        public string Title{get;set;}

        public string Subtitle{get;set;}

        public string Content{get;set;}
       
        public bool Is_Publish{get;set;}

        public DateTime CreateTime { get; set; }=DateTime.Now;

        public Author Author { get; set; }

        public int AuthorId { get; set; }





    }



}