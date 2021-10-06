using API.Models;
using Inv.BLL.Services.Customer;
using Inv.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Controllers;
using Inv.API.Tools;
using System.Web.Http.Cors;
using System.Data.SqlClient;
using System.Data.Entity;
using Inv.DAL.Repository;
using Newtonsoft.Json;
using Inv.API.Models;

namespace API.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    public class CustomerController : BaseController
    {

        private readonly ICustomerServices CustomerServices;

        public CustomerController(ICustomerServices _ICustomerServices)
        {
            CustomerServices = _ICustomerServices;

        }

        [HttpGet, AllowAnonymous]
        public IHttpActionResult GetAll(int CompCode)
        {
            if (ModelState.IsValid)
            {
                var Cust = CustomerServices.GetAll().ToList();

                return Ok(new BaseResponse(Cust));

            }
            return BadRequest(ModelState);
        }

        [HttpGet, AllowAnonymous]
        public IHttpActionResult GetFiltered(int? CreditType, string BalType)
        {

            string s = "select * from CUSTOMER ";
            string condition = "";

            if (CreditType != null && BalType != "All")
            {
                condition = condition + " where IsCreditCustomer =" + CreditType;

                if (BalType == ">")
                {
                    condition = condition + " and  Openbalance > CreditLimit ";
                }
                if (BalType == "=")
                {
                    condition = condition + " and Openbalance = CreditLimit ";
                }
                if (BalType == "<")
                {
                    condition = condition + " and Openbalance < CreditLimit ";
                }


            }


            else if (CreditType != null)
                condition = condition + " where  IsCreditCustomer =" + CreditType;

            else if (BalType != "All")
            {
                if (BalType == ">")
                {
                    condition = condition + " where  Openbalance > CreditLimit ";
                }
                if (BalType == "=")
                {
                    condition = condition + " where Openbalance = CreditLimit ";
                }
                if (BalType == "<")
                {
                    condition = condition + " where Openbalance < CreditLimit "; 
                }

            }

            string query = s + condition;
            var res = db.Database.SqlQuery<CUSTOMER>(query).ToList();
            return Ok(new BaseResponse(res));


        }


        [HttpPost, AllowAnonymous]
        public IHttpActionResult Insert([FromBody]CUSTOMER Nation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Nationality = CustomerServices.Insert(Nation);
                    return Ok(new BaseResponse(Nationality));
                }
                catch (Exception ex)
                {
                    return Ok(new BaseResponse(HttpStatusCode.ExpectationFailed, ex.Message));
                }
            }
            return BadRequest(ModelState);
        }
        [HttpGet, AllowAnonymous]
        public IHttpActionResult Delete(int ID)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CustomerServices.Delete(ID);
                    return Ok(new BaseResponse());
                }
                catch (Exception)
                {
                    return Ok(new BaseResponse(0, "Error"));
                }

            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPost, AllowAnonymous]
        public IHttpActionResult Update([FromBody]CUSTOMER Nation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Nationality = CustomerServices.Update(Nation);
                    return Ok(new BaseResponse(Nationality));
                }
                catch (Exception ex)
                {
                    return Ok(new BaseResponse(HttpStatusCode.ExpectationFailed, ex.Message));
                }
            }
            return BadRequest(ModelState);
        }



        //***************asmaa********************//
        [HttpPost, AllowAnonymous]
        public IHttpActionResult UpdateCustlist(List<CUSTOMER> CUSTOMERList)
        {



            try
            {
                var insertedRecords = CUSTOMERList.Where(x => x.StatusFlag == 'i').ToList();
                var updatedRecords = CUSTOMERList.Where(x => x.StatusFlag == 'u').ToList();
                var deletedRecords = CUSTOMERList.Where(x => x.StatusFlag == 'd').ToList();
                ResponseResult res = new ResponseResult();
                //loop insered 
                if (insertedRecords.Count > 0)
                {
                    foreach (var item in insertedRecords)
                    {
                        var InsertedRec = CustomerServices.Insert(item);
                        return Ok(new BaseResponse(InsertedRec.CUSTOMER_ID));
                    }

                }


                //loop Update 
                if (updatedRecords.Count > 0)
                {
                    foreach (var item in updatedRecords)
                    {
                        var updatedRec = CustomerServices.Update(item);
                        return Ok(new BaseResponse(updatedRec.CUSTOMER_ID));
                    }

                }

                //var ID_CUSTOMER = CustomerServices.GetAll(x => x.PHONE == CUSTOMERList[0].PHONE).ToList();

                //return Ok(new BaseResponse(ID_CUSTOMER[0].CUSTOMER_ID));

            }
            catch (Exception ex)
            {
                return Ok(new BaseResponse(HttpStatusCode.ExpectationFailed, ex.Message));
            }


            return BadRequest(ModelState);
        }



        [HttpGet, AllowAnonymous]
        public IHttpActionResult GetAll_IQ_Catch_Receipt(string startDate, string endDate, int? CustomerId)
        {
            if (ModelState.IsValid)
            {
                string s = "select * from IQ_Catch_Receipt where [Data] >='" + startDate + "' and [Data] <='" + endDate + "'";

                string condition = "";

                if (CustomerId != 0 && CustomerId != null)
                    condition = condition + " and CUSTOMER_ID =" + CustomerId;
                


                string query = s + condition;
                var res = db.Database.SqlQuery<IQ_Catch_Receipt>(query).ToList();
                return Ok(new BaseResponse(res));
            }
            return BadRequest(ModelState);
        }




    }
}
