using Project.Layer.Domain.Entities;

namespace Project.Layer.Data.Repositories
{
    public class ClienteRepository: RepositorioBase<Cliente>
    {
        public void EditarCliente(Cliente cliente)
        {
            //var clienteEmBase = this.ctx.Cliente.First(p => p.Id == cliente.Id);
            //var clienteEntry = ctx.Entry(clienteEmBase);

            //EditarEndereco(cliente);
            //EditarTelefone(cliente);                        
            
            //clienteEntry.CurrentValues.SetValues(cliente);

            //SalvarTodos();
        }        

        private void EditarEndereco(Cliente cliente)
        {
            //ICollection<Endereco> updateItens = cliente.Enderecos;

            //List<Endereco> oldItens = this.ctx.Endereco.Where(x => x.ClienteId == cliente.Id).ToList();

            //List<Endereco> addedItens = updateItens.ExceptBy(oldItens, x => x.Id).ToList();
            //List<Endereco> deletedItens = oldItens.ExceptBy(updateItens, x => x.Id).ToList();


            //foreach (var item in addedItens)
            //{
            //    item.ClienteId = cliente.Id;
            //}

            //deletedItens.ForEach(x => this.ctx.Entry(x).State = EntityState.Deleted);
            //addedItens.ForEach(x => this.ctx.Entry(x).State = EntityState.Added);
        }

        private void EditarTelefone(Cliente cliente)
        {
            //ICollection<Telefone> updateItens = cliente.Telefones;

            //List<Telefone> oldItens = this.ctx.Telefone.Where(x => x.ClienteId == cliente.Id).ToList();

            //List<Telefone> addedItens = updateItens.ExceptBy(oldItens, x => x.Id).ToList();
            //List<Telefone> deletedItens = oldItens.ExceptBy(updateItens, x => x.Id).ToList();


            //foreach (var item in addedItens)
            //{
            //    item.ClienteId = cliente.Id;
            //}

            //deletedItens.ForEach(x => this.ctx.Entry(x).State = EntityState.Deleted);
            //addedItens.ForEach(x => this.ctx.Entry(x).State = EntityState.Added);
        }
    }
}
