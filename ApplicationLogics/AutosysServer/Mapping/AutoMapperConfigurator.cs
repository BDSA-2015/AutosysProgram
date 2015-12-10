﻿using ApplicationLogics.AutosysServer.Mapping.Profiles;
using ApplicationLogics.AutosysServer.Mapping.Profiles.ApplicationLogicProfiles;
using AutoMapper;

namespace ApplicationLogics.AutosysServer.Mapping
{
    /// <summary>
    /// This class will take mapping profiles which enables AutoMapper to
    /// map different objects together. One can create new profiles in the Profiles folder and then
    /// add them here.
    /// 
    /// For more information: 
    /// http://stackoverflow.com/questions/6825244/where-to-place-automapper-createmaps\
    /// https://github.com/AutoMapper/AutoMapper/wiki/Configuration
    /// </summary>
    public static class AutoMapperConfigurator
    {

        /// <summary>
        /// This method will initialize mapping profiles between the logical layer <see cref="ApplicationLogics"/> and the storage layer <see cref="Storage"/>
        /// for Automapper.
        /// To add more profiles just add the following line below an existing profile
        /// 
        ///     cfg.AddProfile(new nameOfProfile());
        /// 
        /// </summary>
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                // UserManagement profiles 
                cfg.AddProfile(new UserManagementStorageProfile());

                // StudyManagement Profiles 
                cfg.AddProfile(new StudyManagementStorageProfile());
                
                //PaperManagement Profiles
                cfg.AddProfile(new PaperManagementStorageProfile());

            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}