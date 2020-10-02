import React from "react";
import "./App.css";
import { PostProvider } from "./Providers/PostProvider";
import PostList from "./Components/PostList";
import PostForm from "./Components/PostForm";
import PostSearch from "./Components/PostSearch";

function App() {
  return (
    <div className="App">
      <PostProvider>
        <PostForm />
        <PostSearch />
        <PostList />
      </PostProvider>
    </div>
  );
}

export default App;