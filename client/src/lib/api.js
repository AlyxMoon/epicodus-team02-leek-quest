export const registerUser = async (username, password) => {
  const response = await fetch('/api/auth/register', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify({
      username,
      password
    })
  });

  return response.json()
}

export const loginUser = async (username, password) => {
  const response = await fetch('/api/auth/login', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify({
      username,
      password
    })
  });

  return response.json()
}

export const leekUserList = async (token) => {
  const response = await fetch('/api/users', {
    method: 'GET',
    headers: {
      Authorization: `Bearer ${token}`,
    },
  });

  return response.json()
}

export const getTokenAuthData = async (token) => {
  const response = await fetch('/api/auth', {
    headers: {
      'Authorization': `Bearer ${token}`,
    },
  })

  return response.json()
}

export const updateUserPosition = async ({ token, direction }) => {
  const response = await fetch(`/api/users/position`, {
    method: 'POST',
    headers: {
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({ direction })
  })

  return response.json()
}