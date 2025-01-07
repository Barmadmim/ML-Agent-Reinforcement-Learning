
1. Prender el Servidor

```bash
pg_ctl -D "C:\Program Files\PostgreSQL\17\data" start
```
2. loguearse
```bash
psql -U postgres
```

3. listar base de datos
```bash
\l
```

4. entrar a base de datos
```bash
\c <nombre base de datos>
```

5. mostrar tablas de base de datos
```bash
\dt
```

6. entrar a tabla de base de datos
```bash
\d nombre_tabla
```
