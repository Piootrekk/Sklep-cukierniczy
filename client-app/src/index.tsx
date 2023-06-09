import React from 'react';
import ReactDOM from 'react-dom/client';
import 'semantic-ui-css/semantic.min.css'
import './app/layout/styles.css';
import Login from './Login';
import reportWebVitals from './reportWebVitals';
import App from './app/layout/App';
import { StoreContext, store } from './app/stores/store';


const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

root.render(
  //<React.StrictMode>
   //<Login/>
   <StoreContext.Provider value={store}>
   <App/>
   </StoreContext.Provider>
  //</React.StrictMode>
);



// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
