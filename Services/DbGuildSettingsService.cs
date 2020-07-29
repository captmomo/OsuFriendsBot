﻿using LiteDB;
using OsuFriendBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace OsuFriendBot.Services
{
    public class DbGuildSettingsService
    {
        private readonly LiteDatabase _database;
        public const string collection = "GuildSettings";

        public DbGuildSettingsService(LiteDatabase database)
        {
            _database = database;
        }

        public Dictionary<ulong, GuildSettings> FindAllToDict()
        {
            return _database.GetCollection<GuildSettings>(collection).FindAll().ToDictionary(x => x.GuildId);
        }

        public bool Upsert(GuildSettings settings)
        {
            return _database.GetCollection<GuildSettings>(collection).Upsert(settings);
        }
    }
}