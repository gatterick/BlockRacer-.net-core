using Microsoft.AspNetCore.Mvc;
using BlockRacer.Mvc.Models;
using BlockRacer.Repositories;
using BlockRacer.Configuration;
using System;

/// Each Controller endpoint has the following logic.
/// 1. Validate client input.
/// 2. Modify the Domain model.
/// 3. Save the Domain model with the help of repositories.
/// 4. Map the domain model to the Rest Resources that client consumes.
/// 5. Send answer to client.
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