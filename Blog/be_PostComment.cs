//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Blog
{
    using System;
    using System.Collections.Generic;
    
    public partial class be_PostComment
    {
        public int PostCommentRowID { get; set; }
        public System.Guid BlogID { get; set; }
        public System.Guid PostCommentID { get; set; }
        public System.Guid PostID { get; set; }
        public System.Guid ParentCommentID { get; set; }
        public System.DateTime CommentDate { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Comment { get; set; }
        public string Country { get; set; }
        public string Ip { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public string ModeratedBy { get; set; }
        public string Avatar { get; set; }
        public bool IsSpam { get; set; }
        public bool IsDeleted { get; set; }
    }
}
