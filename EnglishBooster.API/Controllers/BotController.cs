using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishBooster.API.BusinessLogic;
using EnglishBooster.API.BusinessLogic.Interfaces;
using EnglishBooster.API.BusinessLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace EnglishBooster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotController : ControllerBase
    {
        private readonly ICommandFactory commandFactory;

        public BotController(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        [HttpPost]
        public async Task Post([FromBody]Update update)
        {
            if (update == null)
            {
                return;
            }

            var command = commandFactory.GetCommand(update);

            if (command != null)
            {
                await command.ExecuteAsync();
            }
        }
    }
}