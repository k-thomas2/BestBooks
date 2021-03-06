﻿using BestBooks.Data;
using BestBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BestBooks.Data.ApplicationUser;

namespace BestBooks.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }
        //Create Comment 
        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    OwnerId = _userId,
                    Content = model.CommentContent,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comment.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //Get Comments 
        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comment
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                        new CommentListItem
                        {
                            CommentId = e.CommentId,
                            Content = e.Content
                        }
                        );
                return query.ToArray();
            }
        }

        //GET Comments by ID 
        public CommentDetail GetCommentById(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comment
                        .Single(e => e.CommentId == commentId && e.OwnerId == _userId);
                return
                    new CommentDetail
                    {
                        CommentId = entity.CommentId,
                        CommentContent = entity.Content
                    };
            }
        }

        //Update comments
        public bool UpdateComment(CommentEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comment
                        .Single(e => e.CommentId == model.CommentId && e.OwnerId == _userId);
                entity.Content = model.CommentContent;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteComment(int CommentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comment
                        .Single(e => e.CommentId == CommentId && e.OwnerId == _userId);
                ctx.Comment.Remove(entity);

                return ctx.SaveChanges() == 1;
            
            }
        }
    }
}
