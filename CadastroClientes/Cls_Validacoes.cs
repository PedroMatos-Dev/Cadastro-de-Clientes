using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DisciplinaLP1
{ 
    class Cls_Validacoes
    {
        public static bool ValidaCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            if(new string(cpf[0], cpf.Length) == cpf)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
        
        public static bool ValidaEmail(string email) {
            if (string.IsNullOrWhiteSpace(email)) {
                return false;
            }

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, pattern))
                return false;

            string[] allowedDomains = {
            "gmail.com",
            "gmail.com.br",
            "hotmail.com",
            "outlook.com",
            "bool.com",
            "aluno.ifsp.edu.br",
            "ifsp.edu.br"
            };

            string domain = email.Substring(email.LastIndexOf('@') + 1);

            foreach(var allowedDomain in allowedDomains) {
                if(domain.Equals(allowedDomain, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        public static bool ValidaFacebook(string url) {
            if (string.IsNullOrWhiteSpace(url)) return false;

            string pattern = @"^(https?:\/\/)?(www\.)?facebook\.com\/[a-zA-Z0-9_.-]+$";
            return Regex.IsMatch(url, pattern);
        }

        public static bool ValidaTwitter(string url) {
            if (string.IsNullOrWhiteSpace(url)) return false;

            string pattern = @"^(https?:\/\/)?(www\.)?(twitter\.com|x\.com)\/[a-zA-Z0-9_.-]+$";
            return Regex.IsMatch(url, pattern);
        }

        public static bool ValidaLinkedin(string url) {
            if (string.IsNullOrWhiteSpace(url)) return false;

            string pattern = @"^(https?:\/\/)?(www\.)?linkedin\.com\/in\/[a-zA-Z0-9_-]+\/$";
            return Regex.IsMatch(url, pattern);
        }
    }
}
