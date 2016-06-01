using Microsoft.AspNetCore.Mvc;
using BlockRacer.Models;
using BlockRacer.Repositories;
using BlockRacer.Configuration;
using System;

namespace BlockRacer.Controllers {
    public class PlayerController : ControllerBase {
        public void Get(string guid) {
            if (guid != null) {
                Console.WriteLine("received guid;" + guid);
            }
            else {
                Console.WriteLine("Received no guid");
            }
        }
    }
}