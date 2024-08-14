const setJSONValue = (value) => {
  return JSON.stringify(value);
};

export const getJSONValue = (value) => {
  const jsonText = value;
  return jsonText?.includes("{") ? JSON.parse(value) : null;
};

export const setData = (key, value) => {
  if (key && value) {
    localStorage.setItem(key, setJSONValue(value));
  } else {
    localStorage.removeItem(key);
  }
};

export const getData = (key) => {
  return getJSONValue(localStorage.getItem(key));
};

export const clearData = () => {
  localStorage.clear();
};
