using System.Collections.Generic;

namespace BackEnd.Models
{
    public class Response
    {
        public string message {get;set;}
        public bool status{get;set;}
        public dynamic data{get;set;}
      
        public List<string> errors {get;set;}
    }
    public class ResponseView
    {
        public dynamic data{get;set;}
        public int page {get;set;}
        public int limit {get;set;}
        public int total {get;set;}
        public int totalPage {get;set;}
       
    }
}