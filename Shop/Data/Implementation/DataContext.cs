using Data.API;
using Data.Implementation.DTO;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementation;

internal partial class DataContext : DbContext, IDataContext
{
    public DataContext()
    {

    }

    protected virtual DbSet<DTO.User> users { get; set; }

    protected virtual DbSet<DTO.Product> products { get; set; }

    protected virtual DbSet<DTO.State> states { get; set; }

    protected virtual DbSet<DTO.Event> events { get; set; }

    public IQueryable<IUser> Users => users.Cast<IUser>();

    public IQueryable<IProduct> Products => products.Cast<IProduct>();

    public IQueryable<IState> States => states.Cast<IState>();

    public IQueryable<IEvent> Events => events.Cast<IEvent>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=shop;Integrated Security=True;TrustServerCertificate=true");
    
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
        DTO.Product current = await this.products.FirstAsync(p => p.Id == product.Id);

        current.Name = product.Name;
        current.Price = (decimal)product.Price;
        current.Pegi = product.Pegi;

        await this.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        DTO.Product toDelete = await this.products.FirstAsync(p => p.Id == id);

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


    #region State CRUD

    public async Task AddStateAsync(IState state)
    {
        DTO.State stateEntity = new DTO.State()
        {
            ProductId = state.productId,
            ProductQuantity = state.productQuantity
        };

        await this.states.AddAsync(stateEntity);
        await this.SaveChangesAsync();
    }

    public async Task<IState?> GetStateAsync(int id)
    {
        DTO.State? state = await Task.Run(() =>
        {
            IQueryable<DTO.State> query =
                from s in states
                where s.Id == id
                select s;

            return query.FirstOrDefault();
        });

        return state is not null ? new State(state.Id, state.ProductId, state.ProductQuantity) : null;
    }

    public async Task UpdateStateAsync(IState state)
    {
        DTO.State current = await this.states.FirstAsync(s => s.Id == state.Id);

        current.ProductId = state.productId;
        current.ProductQuantity = state.productQuantity;

        await this.SaveChangesAsync();
    }

    public async Task DeleteStateAsync(int id)
    {
        DTO.State toDelete = await this.states.FirstAsync(s => s.Id == id);

        this.states.Remove(toDelete);

        await this.SaveChangesAsync();
    }

    public async Task<Dictionary<int, IState>> GetAllStatesAsync()
    {
        IQueryable<IState> stateQuery = from s in this.states
            select
                new State(s.Id, s.ProductId, s.ProductQuantity) as IState;

        return await stateQuery.ToDictionaryAsync(p => p.Id);
    }

    public async Task<int> GetStatesCountAsync()
    {
        return await this.states.CountAsync();
    }

    #endregion


    #region Event CRUD

    public async Task AddEventAsync(IEvent even)
    {
        DTO.Event eventEntity = new DTO.Event()
        {
            StateId = even.stateId,
            UserId = even.userId,
            OccurrenceDate = even.occurrenceDate,
        };

        await this.events.AddAsync(eventEntity);
        await this.SaveChangesAsync();
    }    

    public async Task<IEvent?> GetEventAsync(int id, string type)
    {
        DTO.Event? even = await Task.Run(() =>
        {
            IQueryable<DTO.Event> query =
                from e in events
                where e.Id == id
                select e;

            return query.FirstOrDefault();
        });

        IEvent newEvent;

        if (even is null)
            return null;

        switch (type)
        {
            case "PurchaseEvent":
                newEvent = new PurchaseEvent(even.Id, even.StateId, even.UserId, even.OccurrenceDate); break;
            case "ReturnEvent":
                newEvent = new ReturnEvent(even.Id, even.StateId, even.UserId, even.OccurrenceDate); break;
            case "SupplyEvent":
                newEvent = new SupplyEvent(even.Id, even.StateId, even.UserId, even.OccurrenceDate, (int)even.Quantity!); break;
            default:
                throw new Exception("This event type does not exist!");
        }

        return newEvent;
    }    

    public async Task UpdateEventAsync(IEvent even)
    {
        DTO.Event current = await this.events.FirstAsync(e => e.Id == even.Id);

        current.StateId = even.stateId;
        current.UserId = even.userId;
        current.OccurrenceDate = even.occurrenceDate;

        await this.SaveChangesAsync();
    }    

    public async Task DeleteEventAsync(int id)
    {
        DTO.Event toDelete = await this.events.FirstAsync(e => e.Id == id);

        this.events.Remove(toDelete);

        await this.SaveChangesAsync();
    }    

    public async Task<Dictionary<int, IEvent>> GetAllEventsAsync()
    {
        IQueryable<IEvent> stateQuery = from e in this.events
            select
                new PurchaseEvent(e.Id, e.StateId, e.UserId, e.OccurrenceDate) as IEvent;

        return await stateQuery.ToDictionaryAsync(p => p.Id);
    }    

    public async Task<int> GetEventsCountAsync()
    {
        return await this.events.CountAsync();
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

    public async Task<bool> CheckIfStateExists(int id)
    {
        return (await this.GetStateAsync(id)) != null;
    }

    public async Task<bool> CheckIfEventExists(int id, string type)
    {
        return (await this.GetEventAsync(id, type)) != null;
    }

    #endregion


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DTO.User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F4060E7B0");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Balance)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("balance");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("dateOfBirth");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nickname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nickname");
        });

        modelBuilder.Entity<DTO.Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3213E83F453A6F30");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Pegi).HasColumnName("pegi");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<DTO.State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__States__3213E83FB2202D2C");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.ProductQuantity).HasColumnName("productQuantity");

            entity.HasOne(d => d.Product).WithMany(p => p.States)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_States_Products");
        });

        modelBuilder.Entity<DTO.Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Events__3213E83FB34F1E0D");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.OccurrenceDate)
                .HasColumnType("date")
                .HasColumnName("occurrenceDate");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.StateId).HasColumnName("stateId");
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.State).WithMany(p => p.Events)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Events_States");

            entity.HasOne(d => d.User).WithMany(p => p.Events)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Events_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

