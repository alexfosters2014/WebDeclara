﻿namespace ServerDeclara.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
