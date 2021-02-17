﻿using System;

namespace Models.System.DTO

{
    public class AdminUserDTO : BaseResponse.BaseResponseDTO
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public bool Active { get; set; }

        public DateTime? LastLoggedInDateTime { get; set; }


    }
}
