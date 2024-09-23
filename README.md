# Развертка Frontend

## Локально:

1. Добавить файл в папку `frontend\.env` вида:

```
    VUE_APP_CTF_API='https://ctftime.org/api/v1/'
    VUE_APP_API_URL='{api_url}'
```

Если API развернуто через контейнере на 5001 порте, то файл `.env` должен выглядить так:

```
    VUE_APP_CTF_API='https://ctftime.org/api/v1/'
    VUE_APP_API_URL='http://localhost:5001/'
```

2. Выполнить `npm install` находясь в директории frontend.
3. Выполнить `npm run serve` находясь в директории frontend.
4. Приложение будет работать по ссылке: `http://localhost:8080/`
