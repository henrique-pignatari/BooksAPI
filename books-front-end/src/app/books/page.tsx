"use client"
import ListContainer from "@/components/List/ListContainer";
import { useBooksList } from "@/contexts/booksList";

import styles from "./styles.module.scss"

const Books = () => {
  const {fetchList} = useBooksList()
  
  return (
    <ListContainer title="Livros">
      <button onClick={fetchList}>
        FETCH
      </button>
    </ListContainer>
  );
};

export default Books;
