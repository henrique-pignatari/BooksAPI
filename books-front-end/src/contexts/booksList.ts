"use client"
import { ReactNode, useContext } from "react";
import { listProviderFactory } from "./factories/listsFactory";

type Book = {
  title: string;
}

type BooksProviderProps = {
  children: ReactNode;
}

const {context, ProviderElement} = listProviderFactory<Book>();

const BooksListProvider = ({children}: BooksProviderProps) => {
  return(
    ProviderElement(children)
  )
}

const useBooksList = () => {
  return useContext(context)
}

export{
  useBooksList,
  BooksListProvider
}