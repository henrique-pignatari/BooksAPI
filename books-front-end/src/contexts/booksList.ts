"use client";
import { useContext } from "react";
import { listProviderFactory } from "./factories/listsFactory";
import { BOOKS_URL } from "@/global/urls";
import { Publisher } from "./publishersList";
import { Category } from "./categoriesList";
import { Genre } from "./genresList";
import { Author } from "./authorsList";

export type Book = {
  id: string;
  name: string;
  description: string;
  totalPages: number;
  image: string;
  readStatus: number;
  readStartDate: Date;
  readStopDate: Date;
  readConclusionDate: Date;
  publisher: Publisher;
  category: Category;
  genres: Array<Genre>;
  auhtors: Array<Author>;
};

const { context, ProviderElement: BooksListProvider } = listProviderFactory<Book>({
  baseUrl: BOOKS_URL,
});

const useBooksList = () => useContext(context);

export { useBooksList, BooksListProvider };
