﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetNot.MVC.DataContext;
using AspnetNot.MVC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspnetNot.MVC.Controllers
{
    public class NoteController : Controller
    {
        /// <summary>
        /// 게시판 리스트 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {            
            using (var db = new AspnetNoteDbContext())
            {
                var list = db.Notes.ToList(); //모든 리스트 출력 ToList
                return View(list);
            }
            
        }

        /// <summary>
        /// 게시물 추가
        /// </summary>
        /// <returns></returns>
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// 게시물 수정
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit()
        {
            return View();
        }

        /// <summary>
        /// 게시물 삭제
        /// </summary>
        /// <returns></returns>
        public IActionResult Delete()
        {
            return View();
        }
    }
}
