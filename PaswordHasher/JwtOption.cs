﻿namespace PaswordHasher
{
    public class JwtOption
    {
        public string SecretKey { get; set; } = string.Empty;
        public int ExpitesHours { get; set; }
    }
}
