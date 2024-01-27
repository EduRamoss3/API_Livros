using APIEmpresarial.Model.Entities;

namespace APIes.Interfaces
{
    public interface ILoginInterface
    {
        bool Cadastrar(Funcionario funcionario);
        bool Logar(Funcionario funcionario);    
        bool Deslogar(Funcionario funcionario); 

    }
}
