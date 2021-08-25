export const registerUser = async (username, password) => {
  const response = await fetch('http://localhost:5000/api/auth/register', {
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
  const response = await fetch('http://localhost:5000/api/auth/login', {
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

export const getTokenAuthData = async (token) => {
  const response = await fetch('http://localhost:5000/api/auth', {
    headers: {
      'Authorization': `Bearer ${token}`,
    },
  })

  return response.json()
}