using DataAccess;
using prjModel;
using ServerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerAPI.Controllers
{
    [RoutePrefix("Sach")]
    public class SachAPIController : ApiController
    {
        SachDAL sDAL;
        public SachAPIController()
        {
            sDAL = new SachDAL();
        }
        [Route("")]
        public IHttpActionResult GetALL()
        {
            List<Sach> lst = sDAL.GetAll();
            if (lst.Count == 0) return NotFound();
            return Ok(lst);
        }
        [Route("{id}")]
        public IHttpActionResult GetbyID(string id)
        {
            Sach s = sDAL.GetbyID(Convert.ToInt32(id));
            if (s == null) return NotFound();
            return Ok(s);
        }
        [Route("")]
        public IHttpActionResult Post(SachModel model)
        {
            if (!ModelState.IsValid) return BadRequest("error");
            if (sDAL.Add(new Sach()
            {
                MaSach = model.MaSach,
                TenSach = model.TenSach,
                NamXB = model.NamXB,
                NhaXB = model.NhaXB,
                Email = model.Email,
                MaLoai = model.MaLoai
            }))
                return Ok();
            return BadRequest("error");
        }
        [Route("")]
        public IHttpActionResult Put(SachModel model)
        {
            if (!ModelState.IsValid) return BadRequest("error");
            if (sDAL.Update(new Sach()
            {
                MaSach = model.MaSach,
                TenSach = model.TenSach,
                NamXB = model.NamXB,
                NhaXB = model.NhaXB,
                Email = model.Email,
                MaLoai = model.MaLoai
            }))
                return Ok();
            return BadRequest("error");
        }
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (sDAL.Delete(id)) return Ok();
            return NotFound();
        }
    }
}
