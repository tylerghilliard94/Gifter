import React from "react";
import "./App.css";
import { BrowserRouter as Router } from "react-router-dom";
import { PostProvider } from "./Providers/PostProvider";
import ApplicationViews from "./ApplicationViews";
import PostList from "./Components/PostList";
import PostForm from "./Components/PostForm";
import PostSearch from "./Components/PostSearch";
import Header from "./Header";
import { UserProfileProvider } from "./Providers/UserProfileProvider";
import { firebase } from "firebase";

function App() {






  return (
    <div className="App">
      <Router>
        <UserProfileProvider>
          <PostProvider>
            <Header />
            <ApplicationViews />


          </PostProvider>
        </UserProfileProvider>
      </Router>
    </div>
  );
}

export default App;