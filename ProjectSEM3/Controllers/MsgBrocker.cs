
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using System.Text;

namespace ProjectSEM3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MsgBrocker : ControllerBase
    {

        [HttpGet, Route("msg-brocker")]
        public IActionResult Msg()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = "localhost",
                    Port = 5672
                };

                var connection = factory.CreateConnection();
                var channel = connection.CreateModel();
                channel.QueueDeclare(
                    queue: "t2204m",
                             durable: false,
                             exclusive: false,
                             autoDelete: true,
                             arguments: null
                             );
                const string mess = "hello from South";
                var body = Encoding.UTF8.GetBytes(mess);
                channel.BasicPublish(
                    exchange: string.Empty,
                             routingKey: "t2204m",
                             basicProperties: null,
                             body = body
                             );
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    
     

    
}
