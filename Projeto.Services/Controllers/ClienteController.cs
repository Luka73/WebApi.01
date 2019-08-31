using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto.Services.Models;

namespace Projeto.Services.Controllers
{
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {
        [HttpPost] //requisição do tipo POST
        public HttpResponseMessage Post(ClienteCadastroModel model)
        {
            //retornando um status de sucesso!
            return Request.CreateResponse
                (HttpStatusCode.OK, "Cliente cadastrado com sucesso.");
        }

        [HttpPut] //requisição do tipo PUT
        public HttpResponseMessage Put(ClienteEdicaoModel model)
        {
            //retornando um status de sucesso!
            return Request.CreateResponse
                (HttpStatusCode.OK, "Cliente atualizado com sucesso.");
        }

        [HttpDelete] //requisição do tipo DELETE
        public HttpResponseMessage Delete(int id)
        {
            //retornando um status de sucesso!
            return Request.CreateResponse
                (HttpStatusCode.OK, "Cliente excluído com sucesso.");
        }

        [HttpGet] //requisição do tipo GET
        public HttpResponseMessage Get()
        {
            //retornando um status de sucesso!
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet] //requisição GET
        public HttpResponseMessage GetById(int id)
        {
            //retornando um status de sucesso!
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
