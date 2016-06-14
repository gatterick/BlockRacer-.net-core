using Microsoft.AspNetCore.Mvc;
using BlockRacer.Mvc.Models;
using BlockRacer.Repositories;
using BlockRacer.Configuration;
using System;

namespace BlockRacer.Mvc.Controllers {
    public class PlayerController : ControllerBase {
        public void Get(string id) {
            if (id != null) {
                Console.WriteLine("received guid;" + id);
            }
            else {
                Console.WriteLine("Received no guid");
            }
        }
    }
}