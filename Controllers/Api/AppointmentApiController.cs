using Models.Domains;
using Models.Requests;
using Models.Responses;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ViaRepairBTE.Controllers.Api
{
    [RoutePrefix("api/appointment")]
    public class AppointmentApiController : ApiController
    {
        AppointmentService _svc;

        public AppointmentApiController(AppointmentService svc)
        {
            _svc = svc;
        }

        [Route][HttpGet]
        public HttpResponseMessage GetAll()
        {
            ItemsResponse<Appointment> response = new ItemsResponse<Appointment>();
            response.Items = _svc.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{Id:int}")][HttpGet]
        public HttpResponseMessage GetById(int Id)
        {
            ItemResponse<Appointment> response = new ItemResponse<Appointment>();
            response.Item = _svc.GetById(Id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route][HttpPost]
        public HttpResponseMessage Post(AppointmentAddRequest model)
        {
            if(!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _svc.Post(model);
            SuccessResponse response = new SuccessResponse();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{Id:int}")][HttpPut]
        public HttpResponseMessage Put(int Id, AppointmentUpdateRequest model)
        {
            if (!ModelState.IsValid || Id != model.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            } else
            {
                _svc.Put(model);
                SuccessResponse response = new SuccessResponse();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
        }

        [Route("{Id:int}")][HttpDelete]
        public HttpResponseMessage Delete(int Id)
        {
            _svc.Delete(Id);
            SuccessResponse response = new SuccessResponse();
            return Request.CreateResponse(HttpStatusCode.OK, response);          
        }
    }
}
