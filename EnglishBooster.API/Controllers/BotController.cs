﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishBooster.API.BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace EnglishBooster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotController : ControllerBase
    {
        private readonly ITelegramBotClient telegramBotClient;

        public BotController(ITelegramBotClient telegramBotClient)
        {
            this.telegramBotClient = telegramBotClient;
        }

        [HttpPost]
        public async Task Post([FromBody]Update update)
        {
            if (update == null)
            {
                return;
            }

            var decider = new FactoryDecider();
            var commandFactory = decider.GetFactory(telegramBotClient, update);
            var command = commandFactory.GetCommand();

            if (command != null)
            {
                await command.ExecuteAsync();
            }
        }
    }
}