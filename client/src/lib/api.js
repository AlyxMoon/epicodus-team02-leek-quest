//this is sample/fake backend logic to help us pretend to work with the server side
export const registerUser = async (username, password) => {  
  return {
    success: true
  }
}

export const applicationUser = async (username, password) => {  
  try {
    const response = await fetch('OUR API');
    if (!response.ok) {
      throw Error(response.result);
    }
    return response.json();
  } catch (error) {
    return error;
  }
}