using Data.API;
using Data.Implementation.DTO;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementation;

internal partial class DataContext : DbContext, IDataContext
{
    //public Dictionary<string, IUser> users { get; set; }

    //public Dictionary<string, IProduct> products { get; set; }

    //public Dictionary<string, IState> states { get; set; }

    //public Dictionary<string, IEvent> events { get; set; }

    public DataContext()
    {
        //this.users = new Dictionary<string, IUser>();

        //this.products = new Dictionary<string, IProduct>();

        //this.states = new Dictionary<string, IState>();

        //this.events = new Dictionary<string, IEvent>();
    }

    protected virtual DbSet<DTO.User> users { get; set; }

    public IQueryable<IUser> Users => users.Cast<IUser>();

    protected virtual DbSet<DTO.Product> products { get; set; }

    public IQueryable<IProduct> Products => products.Cast<IProduct>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=shop;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DTO.User>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK__Users__3213E83FCD75E293");

            entity.Property(e => e.Nickname)
                .IsRequired()
                .HasColumnName("nickname");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("email");

            entity.Property(e => e.Balance)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("balance");

            entity.Property(e => e.DateOfBirth)
                .HasColumnName("dateOfBirth");
        });

        modelBuilder.Entity<DTO.Product>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK__Products__3213E83F80E46A65");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name");

            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price")
                .IsRequired();

            entity.Property(e => e.Pegi)
                .HasColumnType("integer")
                .HasColumnName("pegi");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    #region User CRUD

    public async Task AddUserAsync(IUser user)
    {
        DTO.User userEntity = new DTO.User()
        {
            Nickname = user.Nickname,
            Email = user.Email,
            Balance = (decimal)user.Balance,
            DateOfBirth = user.DateOfBirth,
        };

        await this.users.AddAsync(userEntity);
        await this.SaveChangesAsync();
    }

    public async Task<IUser?> GetUserAsync(int id)
    {
        DTO.User? user = await Task.Run(() =>
        {
            IQueryable<DTO.User> query =
                from u in users
                where u.Id == id
                select u;

            return query.FirstOrDefault();
        });

        return user is not null ? new User(user.Id, user.Nickname, user.Email, (double)user.Balance, user.DateOfBirth) : null;
    }

    public async Task UpdateUserAsync(IUser user)
    {
        DTO.User current = await this.users.FirstAsync(u => u.Id == user.Id);

        current.Nickname = user.Nickname;
        current.Email = user.Email;
        current.Balance = (decimal)user.Balance;
        current.DateOfBirth = user.DateOfBirth;

        await this.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int id)
    {
        DTO.User toDelete = await this.users.FirstAsync(u => u.Id == id);

        this.users.Remove(toDelete);

        await this.SaveChangesAsync();
    }

    public async Task<Dictionary<int, IUser>> GetAllUsersAsync()
    {
        IQueryable<IUser> usersQuery = from u in this.users
            select
                new User(u.Id, u.Nickname, u.Email, (double)u.Balance, u.DateOfBirth) as IUser;

        return await usersQuery.ToDictionaryAsync(u => u.Id);
    }

    public async Task<int> GetUsersCountAsync()
    {
        return await this.users.CountAsync();
    }

    #endregion


    #region Product CRUD

    public async Task AddProductAsync(IProduct product)
    {
        DTO.Product productEntity = new DTO.Product()
        {
            Name = product.Name,
            Price = (decimal)product.Price,
            Pegi = product.Pegi,
        };

        await this.products.AddAsync(productEntity);
        await this.SaveChangesAsync();
    }

    public async Task<IProduct?> GetProductAsync(int id)
    {
        DTO.Product? product = await Task.Run(() =>
        {
            IQueryable<DTO.Product> query =
                from u in products
                where u.Id == id
                select u;

            return query.FirstOrDefault();
        });

        return product is not null ? new Game(product.Id, product.Name, (double)product.Price, product.Pegi) : null;
    }

    public async Task UpdateProductAsync(IProduct product)
    {
        DTO.Product current = await this.products.FirstAsync(u => u.Id == product.Id);

        current.Name = product.Name;
        current.Price = (decimal)product.Price;
        current.Pegi = product.Pegi;

        await this.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        DTO.Product toDelete = await this.products.FirstAsync(u => u.Id == id);

        this.products.Remove(toDelete);

        await this.SaveChangesAsync();
    }

    public async Task<Dictionary<int, IProduct>> GetAllProductsAsync()
    {
        IQueryable<IProduct> productQuery = from p in this.products
            select
                new Game(p.Id, p.Name, (double)p.Price, p.Pegi) as IProduct;

        return await productQuery.ToDictionaryAsync(p => p.Id);
    }

    public async Task<int> GetProductsCountAsync()
    {
        return await this.products.CountAsync();
    }

    #endregion


    #region Utils

    public async Task<bool> CheckIfUserExists(int id)
    {
        return (await this.GetUserAsync(id)) != null;
    }

    public async Task<bool> CheckIfProductExists(int id)
    {
        return (await this.GetProductAsync(id)) != null;
    }

    #endregion
}

