using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(5);
        }

        [HttpPost]
        public async Task Post([FromBody]Update update)
        {
            if (update == null)
            {
                return;
            }

            var message = update.Message;

            if (message?.Type == MessageType.Text)
            {
                await telegramBotClient.SendTextMessageAsync(message.Chat.Id, message.Text);
            }
        }
    }
}