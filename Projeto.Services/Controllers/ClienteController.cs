using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Projeto.DAL.Entities;
using Projeto.DAL.Repositories;
using Projeto.Services.Models;
using Projeto.Services.Validations;

namespace Projeto.Services.Controllers
{
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {
        [HttpPost] //requisição do tipo POST
        public HttpResponseMessage Post(ClienteCadastroModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var cliente = Mapper.Map<Cliente>(model);
                    ClienteRepository repository = new ClienteRepository();

                    if(repository.SelectByEmail(cliente.Email) == null)
                    {
                        repository.Insert(cliente);

                        //retornando um status de sucesso!
                        return Request.CreateResponse
                            (HttpStatusCode.OK, "Cliente cadastrado com sucesso.");
                    }

                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro. O email informado já existe.");
                }
                catch (Exception e)
                {
                    //HTTP 500 -> Internal Server Error
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                }
            }

            //HTTP 400 -> BadRequest
            return Request.CreateResponse(HttpStatusCode.BadRequest, ValidationUtil.GetErrors(ModelState));
        }

        [HttpPut] //requisição do tipo PUT
        public HttpResponseMessage Put(ClienteEdicaoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cliente = Mapper.Map<Cliente>(model);
                    ClienteRepository repository = new ClienteRepository();
                    repository.Update(cliente);

                    //retornando um status de sucesso!
                    return Request.CreateResponse
                        (HttpStatusCode.OK, "Cliente atualizado com sucesso.");
                }
                catch (Exception e)
                {
                    //HTTP 500 -> Internal Server Error
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                }
            }

            //HTTP 400 -> BadRequest
            return Request.CreateResponse(HttpStatusCode.BadRequest, ValidationUtil.GetErrors(ModelState));
        }

        [HttpDelete] //requisição do tipo DELETE
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                ClienteRepository repository = new ClienteRepository();
                repository.Delete(id);

                return Request.CreateResponse(HttpStatusCode.OK, "Cliente excluído com sucesso!");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet] //requisição do tipo GET
        public HttpResponseMessage Get()
        {
            try
            {
                ClienteRepository repository = new ClienteRepository();
                var lista = repository.SelectAll();

                var model = Mapper.Map<List<ClienteConsultaModel>>(lista);

                //retornando um status de sucesso!
                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet] //requisição GET
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                ClienteRepository repository = new ClienteRepository();
                var cliente = repository.SelectAll();

                var model = Mapper.Map<List<ClienteConsultaModel>>(cliente);

                //retornando um status de sucesso!
                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
