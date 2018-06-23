﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMagshiClient
{
    enum Protocols : byte
    {
        REQUEST_SIGNIN = 21,
        RESPONSE_SIGNIN = 11,
        REQUEST_SIGNOUT = 23,
        RESPONSE_SIGNOUT = 13,
        REQUEST_SIGNUP = 24,
        RESPONSE_SIGNUP = 14,
        RESPONSE_ERROR = 15,
        REQUEST_CREATE_ROOM = 26,
        RESPOSNSE_CREATE_ROOM = 16,
        REQUEST_JOIN_ROOM = 27,
        RESPONSE_JOIN_ROOM = 17,
        REQUEST_GET_HIGHSCORE = 28,
        RESPONSE_GET_HIGHSCORE = 18,
        REQUEST_GET_MY_STATS = 29,
        RESPONSE_GET_MY_STATS = 19,
    };
}