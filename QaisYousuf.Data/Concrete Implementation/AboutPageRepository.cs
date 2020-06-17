﻿using QaisYousuf.Data.Context;
using QaisYousuf.Data.Interfaces;
using QaisYousuf.Models;
using System.Linq;

namespace QaisYousuf.Data.Concrete_Implementation
{
    public class AboutPageRepository:Repository<AboutPage>,IAboutPageRepository
    {
        public AboutPageRepository(UIContext context):base(context)
        {

        }

        public AboutPage GetAboutPageBySlug(string slug)
        {
            return _context.AboutPages.Where(x => x.Slug == slug).SingleOrDefault();
        }

        public bool SlugExists(string slug)
        {
            return _context.AboutPages.Any(x => x.Slug == slug);
        }

        public bool SlugExists(int? id, string slug)
        {
            return _context.AboutPages.Where(x => x.Id != id).Any(x => x.Slug == slug);
        }
    }
}
