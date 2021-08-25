//this is sample/fake backend logic to help us pretend to work with the server side
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

// export const loginUser = async (username, password) => {  
//   return {
//     success: true
//   }
// }