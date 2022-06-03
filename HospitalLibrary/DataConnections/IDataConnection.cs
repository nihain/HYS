﻿using HospitalLibrary.Models;

namespace HospitalLibrary.DataConnections
{
    public interface IDataConnection
    {
        DoctorModel CreateDoctorProfile(DoctorModel model);
    }
}