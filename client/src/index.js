import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import * as serviceWorker from './serviceWorker';
import 'bootstrap/dist/css/bootstrap.min.css';
import firebase from "firebase";


firebase.initializeApp({
  apiKey: "AIzaSyCeJiB74IOxAocK7E4XYlEIlBxamBmntOw",
  authDomain: "gifter-f1965.firebaseapp.com",
  databaseURL: "https://gifter-f1965.firebaseio.com",
  projectId: "gifter-f1965",
  storageBucket: "gifter-f1965.appspot.com",
  messagingSenderId: "593707978525",
  appId: "1:593707978525:web:c7a4461e366a25df011bf4"
});

ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
