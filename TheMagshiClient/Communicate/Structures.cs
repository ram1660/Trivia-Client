using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMagshiClient
{
    public struct LoginRequest
    {
        string username;
        string password;

        public LoginRequest(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
    public struct SignupRequest
    {
        string username;
        string password;
        string email;

        public SignupRequest(string username, string password, string email)
        {
            this.username = username;
            this.password = password;
            this.email = email;
        }
    }
    public struct GetPlayersInRoomRequest
    {
        int roomId;

        public GetPlayersInRoomRequest(int roomId)
        {
            this.roomId = roomId;
        }
    }
    public struct JoinRoomRequest
    {
        int roomId;

        public JoinRoomRequest(int roomId)
        {
            this.roomId = roomId;
        }
    }
    public struct LoginResponse
    {
        int status;

        public LoginResponse(int status)
        {
            this.status = status;
        }
    }
    public struct SignupResponse
    {
        int status;

        public SignupResponse(int status)
        {
            this.status = status;
        }
    }
    public struct LogoutResponse
    {
        int status;

        public LogoutResponse(int status)
        {
            this.status = status;
        }
    }
    public struct JoinRoomResponse
    {
        int status;

        public JoinRoomResponse(int status)
        {
            this.status = status;
        }
    }
    public struct CreateRoomResponse
    {
        int status;

        public CreateRoomResponse(int status)
        {
            this.status = status;
        }
    }
    public struct HighscoreResponse
    {
        int status;
        List<Highscore> highscores;

        public HighscoreResponse(int status)
        {
            this.status = status;
            highscores = new List<Highscore>();
        }
    }
    public struct CreateRoomRequest
    {
        string roomId;
        int maxPlayers;
        int questionCount;
        int answerTimeout;

        public CreateRoomRequest(string roomId, int maxPlayers, int questionCount, int answerTimeout)
        {
            this.roomId = roomId;
            this.maxPlayers = maxPlayers;
            this.questionCount = questionCount;
            this.answerTimeout = answerTimeout;
        }
    }
    public struct ErrorResponse
    {
        string message;
        public ErrorResponse(string message)
        {
            this.message = message;
        }
    }

}
