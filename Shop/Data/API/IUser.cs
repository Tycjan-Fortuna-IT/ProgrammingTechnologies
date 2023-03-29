﻿namespace Shop.Data
{
    public interface IUser
    {
        string Guid { get; }

        string Name { get; set; }

        string Surname { get; set; }

        string Email { get; set; }

        double Balance { get; set; }

        DateTime DateOfBirth { get; set; }

        int PhoneNumber { get; set; }
    }
}